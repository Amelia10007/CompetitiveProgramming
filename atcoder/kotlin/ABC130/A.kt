
fun main(args: Array<String>) {
    val split = readLine()!!.split(' ')
    val x = split[0].toInt()
    val a = split[1].toInt()
    val output = if (x < a) 0 else 10
    println(output)
}