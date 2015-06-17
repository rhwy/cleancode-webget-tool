package fr.egor

import java.io.File

object MyApp extends App{
  case class Config(
    url: String = "",
    out: File = new File("."),
    command: String = "",
    timer: Int = 0,
    avg: Boolean = false
  )

  val parser = new scopt.OptionParser[Config]("Nget") {
    head("nget", "0.1")

    opt[String]('u', "url") required() valueName("<url>") action { (x, c) => 
      c.copy(url = x)
    } text("The Url")

    cmd("get") action { (_, c) => c.copy(command = "get") } text("Get resource from url") children(
      opt[File]('s', "save") required() valueName("<file>") action { (x, c) => 
        c.copy(out = x)
      } text("Save is a file")
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
    case Some(config) =>
      println(config)
    case None =>
      println("Error")
  }
  //Nget(args)
}
