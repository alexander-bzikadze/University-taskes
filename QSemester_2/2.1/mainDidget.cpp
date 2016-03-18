#include "mainWidget.h"

#include <QtWidgets/QVBoxLayout>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QGraphicsRectItem>
#include <QImage>
#include <QPainter>

Widget::Widget(QWidget *parent)
  : QWidget(parent), mScene(0, 0, 200, 150)
{
//  mScene.setSceneRect(0, 0, 200, 150);
  mScene.setBackgroundBrush(Qt::white);

  mView = new QGraphicsView(&mScene, this);
  const auto layout = new QGridLayout(this);
  layout->addWidget(mView, 0, 0, 1, 3);

  const auto rectButton = new QPushButton("Rectangle");
  const auto circleButton = new QPushButton("Circle");
  const auto lineButton = new QPushButton("Line");

  layout->addWidget(rectButton, 1, 0);
  layout->addWidget(circleButton, 1, 1);
  layout->addWidget(lineButton, 1, 2);

   const auto saveButton = new QPushButton("Save as");
   layout->addWidget(saveButton, 2, 0, 1, 3);

   connect(rectButton, SIGNAL(clicked()), this, SLOT(addRect()));
   connect(circleButton, SIGNAL(clicked()), this, SLOT(addCircle()));
   connect(lineButton, SIGNAL(clicked()), this, SLOT(addLine()));
   connect(saveButton, SIGNAL(clicked()), this, SLOT(save()));
}

Widget::~Widget()
{

}

void Widget::addRect()
{
  const auto rect = mScene.addRect(mScene.sceneRect().width()/ 2, mScene.sceneRect().height() / 2, 30, 30);
  rect->setFlag(QGraphicsItem::ItemIsMovable);
  rect->setFlag(QGraphicsItem::ItemIsSelectable);
}

void Widget::addCircle()
{
  const auto circle = mScene.addEllipse(mScene.sceneRect().width()/ 2, mScene.sceneRect().height() / 2, 30, 30);
  circle->setFlag(QGraphicsItem::ItemIsMovable);
  circle->setFlag(QGraphicsItem::ItemIsSelectable);
}

void Widget::addLine()
{
  const auto line = mScene.addLine(mScene.sceneRect().width()/ 2, mScene.sceneRect().height() / 2,
                                   mScene.sceneRect().width()/ 2 + 30, mScene.sceneRect().height() / 2 + 30);
  line->setFlag(QGraphicsItem::ItemIsMovable);
  line->setFlag(QGraphicsItem::ItemIsSelectable);
}

void Widget::save()
{
  QImage image(mScene.sceneRect().width(), mScene.sceneRect().height(),QImage::Format_ARGB32_Premultiplied);
  QPainter painter(&image);
  mScene.render(&painter);
  painter.end();
  image.save("scene.png");
}
