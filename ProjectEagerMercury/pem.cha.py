#!/usr/bin/python

#Change project. Add specifications to a project.

import sys, getopt
import glob, os

extension = ".pro.pem"
project_name = "project_name = "
source = "source:"
specification = "specification:"

def main(argv):
	command = argv
	file = open(str(command[1]), 'r')
	lines = file.readlines()

	j = 0;
	while (lines[j] != (specification + '\n')):
		j += 1
	while (len(lines[j]) > 1):
		j += 1
	lines.insert(j, "\t" + str(command[2]) + "\n")

	file = open(str(command[1]), 'w')
	file.writelines(lines)
	file.close()


	file.close();


	


if __name__ == "__main__":
   main(sys.argv)