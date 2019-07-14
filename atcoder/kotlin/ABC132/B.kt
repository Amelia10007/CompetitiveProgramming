fun main(args: Array<String>) {
    val n = readLine()!!.toInt()
    val array = readLine()!!.split(' ').map { it.toInt() }
    var count = 0
    for (i in 1.until(n - 1)) {
        val c1 = array[i - 1] < array[i] && array[i] < array[i + 1]
        val c2 = array[i - 1] > array[i] && array[i] > array[i + 1]
        if (c1 || c2) count++
    }
    println(count)
}