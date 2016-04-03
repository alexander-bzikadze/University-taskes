#!/usr/bin/python

import sys, getopt
import glob, os

extension = ".pro.pem"
project_name = "project_name = "
source = "source:"
specification = "specification:"

def main(argv):
	command = argv
	file = open(str(command[1]) + extension, 'w')
	file.write(project_name + str(command[1]) + '\n\n')
	file.write(source + "\n\n")
	file.write(specification + "\n\n")
	file.close();
	


if __name__ == "__main__":
   main(sys.argv)