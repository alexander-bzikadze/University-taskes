#include "deleteLineCommand.hpp"

DeleteLineCommand::DeleteLineCommand(QGraphicsItem *const line) :
	deletedLine(line)
{}

QGraphicsItem* DeleteLineCommand::act()
{
	deletedLine->setVisible(true);
	return deletedLine;
}

QGraphicsItem* DeleteLineCommand::react()
{
	deletedLine->setVisible(false);
	return deletedLine;
}