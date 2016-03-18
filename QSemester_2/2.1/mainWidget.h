#pragma once

#include <QtWidgets/QWidget>
#include <QtWidgets/QGraphicsView>
#include <QtWidgets/QGraphicsScene>
#include <QPushButton>

class Widget : public QWidget
{
  Q_OBJECT

public:
  Widget(QWidget *parent = 0);
  ~Widget();

private:
  QGraphicsScene mScene;
  QGraphicsView *mView;

public slots:
  void addRect();
  void addCircle();
  void addLine();
  void save();
};
