import { fetchList, createStudent, updateStudent, deleteStudent } from "@/services/studentService"

const state = {
    students: [],
    selected: undefined,
    dialog: false,
    loading: true,
}

const getters = {
    students(state) {
        return state.students
    }
};


const mutations = {
    setstudents(state, params) {
        state.students = params;
    },
    setLoading(state, params) {
        state.loading = params;
    },
    setDialog(state, params) {
        state.dialog = params;
    },
    setSelected(state, params) {
        state.selected = params;
    },
    updateStudent(state, student) {
        const itemIndex = state.students.findIndex(x => x.id === student.id)
        state.students[itemIndex] = student;
    },
    addStudent(state, student) {
        state.students.push(student)
    },
};

const actions = {
    async fetchStudents({ commit }) {
        commit('setLoading', true)
        commit('setstudents', await fetchList())
        commit('setLoading', false)
    },
    setDialog({ commit }, params) {
        commit('setDialog', params)
    },
    addStudentDialog({ commit }) {
        commit('setSelected', null)
        commit('setDialog', true)
    },
    editStudentDialog({ commit }, params) {
        commit('setSelected', params)
        commit('setDialog', true)
    },
    async createStudent({ commit }, student) {
        commit('setLoading', true)
        const id = await createStudent(student)
        commit('addStudent', { id, ...student })
        commit('setSelected', null)
        commit('setLoading', false)
        commit('setDialog', false)
    },
    async updateStudent({ commit }, student) {
        commit('setLoading', true)
        await updateStudent(student)
        commit('setSelected', null)
        commit('updateStudent', student)
        commit('setLoading', false)
        commit('setDialog', false)
    },
    async deleteStudent({ commit, state }, id) {
        commit('setLoading', true)
        await deleteStudent(id)
        commit('setstudents', state.students.filter(i => i.id !== id))
        commit('setDialog', false)
        commit('setLoading', false)
    }
};

export default {
    state, getters, mutations, actions
};