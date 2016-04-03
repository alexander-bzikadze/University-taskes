#!/usr/bin/python

import sys, getopt
import glob, os

extension = ".pro.pem"
cre = "./pem.cre.py "
cha = "./pem.cha.py "
add = "./pem.add.py "
dld = "./pem.dld.py "

def main(argv):
	command = argv
	command.pop(0)
	if (len(command) < 1):
		command.append(0)
	while (command[0] != "q"):
		if (command[0] == "cre"):
			pro_files = glob.glob("*" + extension)
			if (len(pro_files) > 0):
				print "Project already exists! Choose another directory or delete current Project!"
				print "Current project is " + pro_files[0]
			else:
				if (len(command) < 2):
					print "Enter Project Name."
					command.append(raw_input().split()[0])
				os.system(cre + command[1])
				print command[1] + " project has been created."

		elif (command[0] == "del"):
			pro_files = glob.glob("*" + extension)
			if (len(pro_files) < 1):
				print "No projects to delete!"
			elif (len(pro_files) > 1):
				print "There are more than one project in current directory."
				print "Do you want to delete them all?"
				print "y/n or "
				command = raw_input().split()
				while ((command[0] != "y" and command[0] != "n") or len(command) != 1):
					print "Wrong input. Type properer: y/n"
					command = raw_input().split()
				if (command[0] == "y"):
					for f in pro_files:
						os.system(dld + f)
						os.remove(f)
					print "All projects were deleted."
				elif (command[0] == "n"):
					print "Leaving it as it is."
			else:
				for f in pro_files:
					os.system(dld + f)
					os.remove(f)
				print "Project has been deleted."

		elif (command[0] == "cha"):
			pro_files = glob.glob("*" + extension)
			if (len(pro_files) < 1):
				print "No project found to be changed!"
				continue
			elif (len(pro_files) > 1):
				print "To much projects in current directory, cannot be processed."
				print "Consider deleting some of the projects."

			if (len(command) < 2):
				print "Type needed specification"
				command.append(raw_input().split())

			os.system(cha + str(pro_files[0]) + ' ' +str(command[1]))

		elif (command[0] == "add"):
			pro_files = glob.glob("*" + extension)
			if (len(pro_files) < 1):
				print "No project found to be have a source added!"
			elif (len(pro_files) > 1):
				print "To much projects in current directory, cannot be processed."
				print "Consider deleting some of the projects."
			else:
				if (len(command) < 2):
					print "Type added source"
					command.append(raw_input().split())

				os.system(add + str(pro_files[0]) + ' ' +str(command[1]))



		print "Enter command."
		command = raw_input().split()
	

if __name__ == "__main__":
	main(sys.argv)