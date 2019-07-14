data class Task(val needTime: Int, val deadline: Int)

fun main(args: Array<String>) {
    val n = readLine()!!.toInt()
    val tasks = (0.until(n)).map {
        val arr = readLine()!!.split(' ').map { it.toInt() }
        Task(arr[0], arr[1])
    }.sortedBy { it.deadline }
    var sum = 0
    for (i in 0.until(tasks.size)) {
        sum += tasks[i].needTime
        if (tasks[i].deadline < sum) {
            println("No")
            return
        }
    }
    println("Yes")
}
