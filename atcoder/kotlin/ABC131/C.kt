fun dividableCount(max: Long, divider: Long): Long {
    return max / divider
}

fun dividableCount(min: Long, max: Long, divider: Long): Long {
    var count = dividableCount(max, divider) - dividableCount(min, divider)
    if (min % divider == 0L) count++
    return count
}

fun gcd(i1: Long, i2: Long): Long {
    var m = i1
    var n = i2
    var temp: Long
    while (m % n != 0L) {
        temp = n
        n = m % n
        m = temp
    }
    return n
}

fun koubaisu(i1: Long, i2: Long) = i1 * i2 / gcd(i1, i2)

fun main(args: Array<String>) {
    val inputs = readLine()!!.split(' ').map { it.toLong() }
    val a = inputs[0]
    val b = inputs[1]
    val c = inputs[2]
    val d = inputs[3]
    val allnum = b - a + 1
    val dividableByC = dividableCount(a, b, c)
    val dividableByD = dividableCount(a, b, d)
    val cdprouct = koubaisu(c, d)
    val dividableByCandD = dividableCount(a, b, cdprouct)
    val result = allnum - dividableByC - dividableByD + dividableByCandD
    println(result)
}
