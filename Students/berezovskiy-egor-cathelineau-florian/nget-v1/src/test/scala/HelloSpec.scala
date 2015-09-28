import org.scalatest._
import fr.egor.Nget

class ArgsParserTest extends FlatSpec with Matchers {
  "Hello" should "have tests" in {
    val value = Array("get", "-url", "http//berezovskiy.fr")
    val expected = """<!DOCTYPE html>
                     |<html>
                     |<head>
                     |  <meta charset="UTF-8" />
                     |  <title>Bookmarks</title>
                     |  <meta name="viewport" content="width=device-width, initial-scale=1">
                     |  <meta name="description" content="">
                     |  <link rel="stylesheet" href="/assets/stylesheets/main.css" />
                     |</head>
                     |<body></body>
                     |<script src="/assets/javascripts/Main.js"></script>
                     |</html>"""
    true should === (true)
  }
}
