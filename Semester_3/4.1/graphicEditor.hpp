#pragma once

#include <QWidget>
#include <QGraphicsView>
#include <QGraphicsScene>
#include <QPushButton>

#include "stack.hpp"
#include "command.hpp"

/// Graphic editor that can:
/// add lines, move lines, delete lines, undo/redo.
class GraphicEditor : public QWidget
{
	Q_OBJECT
public:
	/// Standart constructor. Sets given as QWidget as base object.
	GraphicEditor(QWidget *parent = 0);
	~GraphicEditor() = default;

private:
	QGraphicsScene mScene;
	QGraphicsView *mView;

	QPushButton* addButton;
	QPushButton* moveButton;
	QPushButton* deleteButton;
	QPushButton* acceptButton;
	QPushButton* denyButton;
	QPushButton* undoButton;
	QPushButton* redoButton;

	QGraphicsEllipseItem* addCircle();
	void removeAuxCircles();
	void addAuxCircles();
	void removeCircle(QGraphicsEllipseItem*& circle);
	QPointF getCircleCenter(QGraphicsEllipseItem*);

	qreal constexpr static circleSize = 6;
	QGraphicsEllipseItem* firstAuxCircle = nullptr;
	QGraphicsEllipseItem* secondAuxCircle = nullptr;
	

	QGraphicsLineItem* addLine(QPointF p1, QPointF p2);
	QPointF const static startPos;
	QPointF const static destPos;

	Stack<Command*> toUndo;
	Stack<Command*> toRedo;
	void cleanToRedoStack();
	void enableOrDisableUndoRedoButtons();

private slots:
	void addLine();
	void moveLine();
	void deleteLine();
	void acceptMove();
	void denyMove();
	void undo();
	void redo();
};