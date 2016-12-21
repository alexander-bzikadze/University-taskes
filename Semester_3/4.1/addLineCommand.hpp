#pragma once

#include "command.hpp"

/// Command that undoes/redoes addition of a line.
class AddLineCommand : public Command
{
public:
	/// Takes just added line.
	AddLineCommand(QGraphicsItem* line);

	/// Deletes contained line.
	~AddLineCommand();

	/// Sets line invisible.
	QGraphicsItem* act() override;

	/// Sets line visible.
	QGraphicsItem* react() override;

private:
	QGraphicsItem* addedLine;
};