fun main(args: Array<String>) {
    val split = readLine()!!.split(' ')
    val n = split[0].toInt()
    val x = split[1].toInt()
    val ls = readLine()!!
        .split(' ')
        .map { it.toInt() }
    var count = 1
    var position = 0
    for (l in ls) {
        position += l
        if (position > x) break
        count++
    }
    println(count)
}
