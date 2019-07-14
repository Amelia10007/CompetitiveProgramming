fun main(args: Array<String>) {
    val s = readLine()!!
    val group = s.groupBy { it }
    if (group.size == 2 && group.all { it.value.size == 2 }) println("Yes")
    else println("No")
}
