fun main(args: Array<String>) {
    readLine()
    val difficulties = readLine()!!.split(' ').map { it.toInt() }.sorted()
    if (difficulties.size <= 2) {
        println(difficulties[1] - difficulties[0])
        return
    }
    val leftDifficulty = difficulties[difficulties.size / 2 - 1]
    val rightDifficulty = difficulties[difficulties.size / 2]
    val k = rightDifficulty - leftDifficulty
    println(k)
}
