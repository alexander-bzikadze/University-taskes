#pragma once

#include <QtWidgets/QWidget>
#include <QtWidgets/QGraphicsView>
#include <QtWidgets/QGraphicsScene>
#include <QPushButton>

/// Class that describes an application with UI.
/// Contains visible scene and three buttons:
/// Rectangle, Circle and Line to add this figures to the scene
/// and Save button to save current scene as .png file.
class Widget : public QWidget
{
  Q_OBJECT

public:
  Widget(QWidget *parent = 0);
  ~Widget();

private:
  QGraphicsScene mScene;
  QGraphicsView *mView;

private slots:
  void addRect();
  void addCircle();
  void addLine();
  void save();
};
