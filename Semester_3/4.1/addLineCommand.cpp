#include "addLineCommand.hpp"

AddLineCommand::AddLineCommand(QGraphicsItem *const line) :
	addedLine(line)
{}

AddLineCommand::~AddLineCommand()
{
	delete addedLine;
}

QGraphicsItem* AddLineCommand::act()
{
	addedLine->setVisible(false);
	return addedLine;
}

QGraphicsItem* AddLineCommand::react()
{
	addedLine->setVisible(true);
	return addedLine;
}