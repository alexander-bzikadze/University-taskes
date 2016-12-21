#pragma once

#include "command.hpp"
#include "deleteLineCommand.hpp"

/// Command that undoes/redoes moving of a line.
class MoveLineCommand : public Command
{
public:
	/// Takes just moved line and command, that has hidden its previous inplacement.
	MoveLineCommand(QGraphicsItem* line, Command* command);

	/// Deletes contained command.
	~MoveLineCommand();

	/// Sets invisible line and acts command.
	QGraphicsItem* act() override;

	/// Sets visible line and reacts command.
	QGraphicsItem* react() override;

private:
	Command* command;
	QGraphicsItem* movedLine;
};