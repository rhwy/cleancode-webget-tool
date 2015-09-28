package fr.egor

import java.io.File
import java.net.{MalformedURLException, URL}
import java.nio.charset.MalformedInputException
import scala.io.Source
import scala.sys.process._

object Nget {
  def apply(config: Config): Unit = config match {

    case Config("test", url, _, number, true) =>
      println(testAvg(url, number.toString))
    
    case Config("test", url, _, number, false) =>
      testUrlConnections(url, number.toString)
    
    case Config("get", url, path, 0, _) =>
      try {
        new URL(url) #> new File(path) !
      } catch {
        case e: Exception => println(e.getMessage)
      }

    case Config("get", url, _, _, _) => get(url) match {
      case Some(result) => result.foreach(println)
      case None => println("Error")
    }

    case _ =>
      println("Wrong args")
  }

  def testAvg(url: String, number: String): Long = {
    (0 to number.toInt).map { i =>
      getUrlConnectionTime(url)
    }.foldLeft(0l){
      case (acc, Some(i)) =>
        acc + i
      case (acc, None) =>
        acc
    } / number.toInt
  }

  def testUrlConnections(url: String, number: String) = {
    try {
      0 to number.toInt foreach { i =>
        getUrlConnectionTime(url) match {
          case Some(duration) =>
            println(s"TEST:$i - duration=${getUrlConnectionTime(url)} ms -> $url")
          case None => println(s"TEST:$i - error -> $url")
        }
      }
    } catch {
      case e: Exception => println(e.getMessage)
    }
  }

  def getUrlConnectionTime(url: String): Option[Long] = {
    try {
      val begin = System.currentTimeMillis()
      val connection = new URL(url).openConnection()
      connection.setUseCaches(false)
      connection.connect()
      Some(System.currentTimeMillis() - begin)
    } catch {
      case e: Exception => None
    }
  }

  def get(url: String): Option[Iterator[String]] = {
    try {
      val connection = new URL(url).openConnection()
      connection.setUseCaches(false)
      val is = connection.getInputStream
      val res = Source.fromInputStream(is)(io.Codec("UTF-8")).getLines()
      //is.close()
      Some(res)
    } catch {
      case e: MalformedInputException =>
        println(Console.RED + e.getMessage)
        None
      case e: MalformedURLException =>
        println(Console.RED + e.getMessage)
        None
    }
  }
}
