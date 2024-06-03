import axiosInstance from "./fetcher"

export async function fetchList() {
    try {
        const { data } = await axiosInstance.get('students')
        return data
    } catch (e) {
        // handle error
    }
}

export async function createStudent(student) {
    try {
        const { data } = await axiosInstance.post('students', student)
        return data
    } catch (e) {
        // handle error
    }
}

export async function updateStudent(student) {
    try {
        const { data } = await axiosInstance.put(`students/${student.id}`, student)
        return data
    } catch (e) {
        // handle error
    }
}

export async function deleteStudent(id) {
    try {
        const { data } = await axiosInstance.delete(`students/${id}`)
        return data
    } catch (e) {
        // handle error
    }

}

