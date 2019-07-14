fun abs(x: Int) = if (x < 0) -x else x

fun main(args: Array<String>) {
    val inputs = readLine()!!.split(' ').map { it.toInt() }
    val n = inputs[0]
    val l = inputs[1]
    val tastes = (0.until(n)).map { i -> l + i }
    val allapplepietaste = tastes.sum()
    val subtastes = (0.until(n)).map { i -> allapplepietaste - tastes[i] }
    val subtaste = subtastes.minBy { sub -> abs(allapplepietaste - sub) }
    println(subtaste)
}
