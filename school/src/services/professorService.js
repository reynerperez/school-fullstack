import axiosInstance from "./fetcher"

export async function fetchList() {
    try {
        const { data } = await axiosInstance.get('professors')
        return data
    } catch (e) {
        // handle error
    }
}

export async function createProfessor(professor) {
    try {
        const { data } = await axiosInstance.post('professors', professor)
        return data
    } catch (e) {
        // handle error
    }
}

export async function updateProfessor(professor) {
    try {
        const { data } = await axiosInstance.put(`professors/${professor.id}`, professor)
        return data
    } catch (e) {
        // handle error
    }
}

export async function deleteProfessor(id) {
    try {
        const { data } = await axiosInstance.delete(`professors/${id}`)
        return data
    } catch (e) {
        // handle error
    }

}

