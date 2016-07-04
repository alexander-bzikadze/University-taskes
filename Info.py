import sublime, sublime_plugin, os

class Info(sublime_plugin.TextCommand):
	def run(self, edit):
		infoFileName = sublime.packages_path()
		if os.name == "Windows":
			infoFileName += "\\User\\Pem\\Info.txt"
		else:
			infoFileName += "/User/Pem/Info.txt"

		infoFile = open(infoFileName)

		lines = infoFile.readlines()
		n = int(lines[0])
		print lines[n + 1]
		self.view.insert(edit, 0, lines[n])

		infoFile.close()

