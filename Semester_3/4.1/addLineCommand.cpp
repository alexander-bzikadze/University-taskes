#include "addLineCommand.hpp"

AddLineCommand::AddLineCommand(QGraphicsItem* line) :
	addedLine(line)
{}

AddLineCommand::~AddLineCommand()
{
	if (addedLine != nullptr)
	{
		delete addedLine;
	}
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