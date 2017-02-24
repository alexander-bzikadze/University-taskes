#pragma once

#include <QGraphicsScene>
#include <QGraphicsLineItem>

/// Abstract class for graphic editor commands.
/// Is used to undo/redo actions in the editor.
class Command
{
public:
	virtual ~Command() = default;

	/// Undoes contained command.
	virtual QGraphicsItem* act() = 0;

	/// Redoes contained command.
	virtual QGraphicsItem* react() = 0;
protected:
	Command() = default;
};