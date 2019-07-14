fun main(args: Array<String>) {
    val inputs = readLine()!!.map { it.toInt() }.toIntArray()
    if (inputs[0] == inputs[1] || inputs[1] == inputs[2] || inputs[2] == inputs[3])
        println("Bad")
    else
        println("Good")
}
