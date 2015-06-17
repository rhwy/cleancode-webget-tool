package fr.egor

import java.io.File
import java.net.{MalformedURLException, URL}
import java.nio.charset.MalformedInputException

import scala.io.Source

import scala.sys.process._

object Nget {
  def apply(args: Array[String]): Unit = args match {
    case Array("get", "-url", url) => get(url) match {
      case Some(result) => result.foreach(println)
      case None => println("Error")
    }

    case Array("get", "-url", url, "-save", path) =>
      try {
        new URL(url) #> new File(path) !
      } catch {
        case e: Exception => println(e.getMessage)
      }

    case Array("test", "-url", url, "-times", number) =>
      testUrlConnections(url, number)

    case Array("test", "-url", url, "-times", number, "-avg") =>
      println(testAvg(url, number))

    case _ =>
      println("Wrong args number: Usage: nget methode -url 'url'")
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
