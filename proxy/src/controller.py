import cherrypy


class HelloWorld(object):
    def index(self):
        return "Hello World!"

    index.exposed = True


cherrypy.server.socket_host = '192.168.1.25'

cherrypy.quickstart(HelloWorld())
