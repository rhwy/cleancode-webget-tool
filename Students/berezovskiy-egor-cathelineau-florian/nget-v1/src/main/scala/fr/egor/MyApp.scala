package fr.egor

import java.io.File

object MyApp extends App{
  val parser = new scopt.OptionParser[Config]("Nget") {
    head("nget", "0.1")

    opt[String]('u', "url") required() valueName("<url>") action { (x, c) => 
      c.copy(url = x)
    } text("The Url")

    cmd("get") action { (_, c) => c.copy(command = "get") } text("Get resource from url") children(
      opt[String]('s', "save") required() valueName("<path>") action { (x, c) => 
        c.copy(path = x)
      } text("Save to file")
    )

    cmd("test") action { (_, c) => c.copy(command = "test") } text("Test resource from url") children(
      opt[Int]('t', "times") required() valueName("<number>") action { (x, c) => 
        c.copy(timer = x)
      } text("Times is a file"),

      opt[Unit]('a', "avg") action { (_, c) => 
        c.copy(avg = true)
      } text("Times is a file")
    )
  }

  parser.parse(args, Config()) match {
    case Some(config) => Nget(config)
    case None => println("Error")
  }
}
