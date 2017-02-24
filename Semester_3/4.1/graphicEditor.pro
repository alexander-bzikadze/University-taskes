CONFIG += c++11

DESTDIR = bin

HEADERS += graphicEditor.hpp command.hpp addLineCommand.hpp deleteLineCommand.hpp moveLineCommand.hpp 

QMAKE_CXXFLAGS += -std=c++11 -v -Wall
QT += core gui
greaterThan(QT_MAJOR_VERSION, 5): QT += widgets

SOURCES += main.cpp graphicEditor.cpp addLineCommand.cpp deleteLineCommand.cpp moveLineCommand.cpp

TEMPLATE = app

OBJECTS_DIR = obj

MOC_DIR = src