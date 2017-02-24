#pragma once

#include "command.hpp"

/// Command that undoes/redoes deletion of a line.
class DeleteLineCommand : public Command
{
public:
	/// Takes just deleted line. In fact it is just set invisible.
	DeleteLineCommand(QGraphicsItem *const line);

	/// Does not delete contained line, as it is supposed to visible at the moment.
	~DeleteLineCommand() = default;

	/// Sets line visible.
	QGraphicsItem* act() override;

	/// Sets line invisible.
	QGraphicsItem* react() override;

private:
	QGraphicsItem *const deletedLine;
};