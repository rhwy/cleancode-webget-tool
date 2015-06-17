name := """ScalaCleanCode"""

version := "1.0"

scalaVersion := "2.11.6"

libraryDependencies ++= Seq(
  "org.scalatest" %% "scalatest" % "2.2.4" % "test",
  "com.github.scopt" %% "scopt" % "3.3.0",
  "com.typesafe.akka" %% "akka-actor" % "2.3.11"
)

resolvers += Resolver.sonatypeRepo("public")


