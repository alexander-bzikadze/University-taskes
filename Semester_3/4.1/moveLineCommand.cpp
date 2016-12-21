#include "moveLineCommand.hpp"

MoveLineCommand::MoveLineCommand(QGraphicsItem* line, Command* command) :
	command(command) ,
	movedLine(line)
{}

MoveLineCommand::~MoveLineCommand()
{
	if (command != nullptr)
	{
		delete command;
	}
}

QGraphicsItem* MoveLineCommand::act()
{
	movedLine->setVisible(false);
	auto line = command->act();
	return line;
}

QGraphicsItem* MoveLineCommand::react()
{
	movedLine->setVisible(true);
	command->react();
	return movedLine;
}
