package fr.egor

class ArgsParser(args: Array[String]) {
  def parse(f: (String, Map[String, String]) => Command) = {
    args(0) match {
      case "get" => ???
    }
  }
}
