#include "graphicEditor.hpp"

#include <QVBoxLayout>
#include <QHBoxLayout>
#include <QGraphicsRectItem>
#include <QGraphicsObject>

#include <iostream>
#include "addLineCommand.hpp"
#include "deleteLineCommand.hpp"
#include "moveLineCommand.hpp"

using namespace std;

GraphicEditor::GraphicEditor(QWidget *parent) :
	QWidget(parent) ,
	mScene(0, 0, 300, 200) ,
	mView(new QGraphicsView(&mScene, this))
{
	mScene.setBackgroundBrush(Qt::white);  
	const auto layout = new QGridLayout(this);
	layout->addWidget(mView, 0, 0, 1, 6);

	addButton = new QPushButton("Add line");
	moveButton = new QPushButton("Move line");
	deleteButton = new QPushButton("Delete line");
	acceptButton = new QPushButton("Accept moving");
	denyButton = new QPushButton("Deny moving");
	undoButton = new QPushButton("UNDO");
	redoButton = new QPushButton("REDO");

	layout->addWidget(addButton, 1, 0, 1, 2);
	layout->addWidget(moveButton, 1, 2, 1, 2);
	layout->addWidget(deleteButton, 1, 4, 1, 2);
	layout->addWidget(acceptButton, 2, 0, 1, 3);
	layout->addWidget(denyButton, 2, 3, 1, 3);
	layout->addWidget(undoButton, 3, 0, 1, 3);
	layout->addWidget(redoButton, 3, 3, 1, 3);

	acceptButton->setEnabled(false);
	denyButton->setEnabled(false);
	enableOrDisableUndoRedoButtons();

	connect(addButton, SIGNAL(clicked()), this, SLOT(addLine()));
	connect(moveButton, SIGNAL(clicked()), this, SLOT(moveLine()));
	connect(deleteButton, SIGNAL(clicked()), this, SLOT(deleteLine()));
	connect(acceptButton, SIGNAL(clicked()), this, SLOT(acceptMove()));
	connect(denyButton, SIGNAL(clicked()), this, SLOT(denyMove()));
	connect(undoButton, SIGNAL(clicked()), this, SLOT(undo()));
	connect(redoButton, SIGNAL(clicked()), this, SLOT(redo()));
}

QPointF const GraphicEditor::startPos = QPointF(0, 0);
QPointF const GraphicEditor::destPos = QPointF(30, 30);

void GraphicEditor::addLine()
{
	auto line = addLine(startPos, destPos);
	toUndo.push(new AddLineCommand(line));
	cleanToRedoStack();
	enableOrDisableUndoRedoButtons();
}

QGraphicsLineItem* GraphicEditor::addLine(QPointF p1, QPointF p2)
{
	auto* line = mScene.addLine(p1.x(), p1.y(), p2.x(), p2.y());
	line->setFlag(QGraphicsItem::ItemIsMovable, false);
	line->setFlag(QGraphicsItem::ItemIsSelectable);
	return line;
}

QGraphicsEllipseItem* GraphicEditor::addCircle()
{
	QPointF const static point(mScene.width() / 2, mScene.height() / 2);
	const auto circle = mScene.addEllipse(0, 0, circleSize, circleSize);
	circle->setPos(point);
	circle->setFlag(QGraphicsItem::ItemIsMovable);
	circle->setFlag(QGraphicsItem::ItemIsSelectable);
	return circle;
}

void GraphicEditor::moveLine()
{
	if (mScene.selectedItems().length() != 1)
	{
		return;
	}
	deleteLine();

	addAuxCircles();

	addButton->setEnabled(false);
	moveButton->setEnabled(false);
	deleteButton->setEnabled(false);
	acceptButton->setEnabled(true);
	denyButton->setEnabled(true);
	undoButton->setEnabled(false);
	redoButton->setEnabled(false);
}

void GraphicEditor::deleteLine()
{
	if (mScene.selectedItems().length() != 1)
	{
		return;
	}
	const auto deletedLine = mScene.selectedItems()[0];
	cleanToRedoStack();
	toUndo.push(new DeleteLineCommand(deletedLine));
	toUndo.top()->react();
	enableOrDisableUndoRedoButtons();
}

void GraphicEditor::acceptMove()
{
	auto line = addLine(getCircleCenter(firstAuxCircle), getCircleCenter(secondAuxCircle));
	addButton->setEnabled(true);
	moveButton->setEnabled(true);
	deleteButton->setEnabled(true);
	acceptButton->setEnabled(false);
	denyButton->setEnabled(false);

	toUndo.push(new MoveLineCommand(line, toUndo.pop()));
	enableOrDisableUndoRedoButtons();

	removeAuxCircles();
}

void GraphicEditor::denyMove()
{
	undo();
	addButton->setEnabled(true);
	moveButton->setEnabled(true);
	deleteButton->setEnabled(true);
	acceptButton->setEnabled(false);
	denyButton->setEnabled(false);
	enableOrDisableUndoRedoButtons();

	removeAuxCircles();
}

void GraphicEditor::undo()
{
	if (toUndo.size())
	{
		auto command = toUndo.pop();
		command->act();
		toRedo.push(command);
	}
	enableOrDisableUndoRedoButtons();
}

void GraphicEditor::redo()
{
	if (toRedo.size())
	{
		auto command = toRedo.pop();
		command->react();
		toUndo.push(command);
	}
	enableOrDisableUndoRedoButtons();
}

QPointF GraphicEditor::getCircleCenter(QGraphicsEllipseItem* circle)
{
	return circle->scenePos() + QPointF(circleSize / 2, circleSize / 2);
}

void GraphicEditor::addAuxCircles()
{
	firstAuxCircle = addCircle();
	secondAuxCircle = addCircle();
}

void GraphicEditor::removeAuxCircles()
{
	removeCircle(firstAuxCircle);
	removeCircle(secondAuxCircle);
}

void GraphicEditor::removeCircle(QGraphicsEllipseItem*& circle)
{
	mScene.removeItem(circle);
	delete circle;
	circle = nullptr;
}

void GraphicEditor::cleanToRedoStack()
{
	while (toRedo.size())
	{
		delete toRedo.pop();
	}
}

void GraphicEditor::enableOrDisableUndoRedoButtons()
{
	undoButton->setEnabled((bool)toUndo.size());
	redoButton->setEnabled((bool)toRedo.size());
}

