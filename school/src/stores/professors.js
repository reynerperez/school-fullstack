import { fetchList, createProfessor, updateProfessor, deleteProfessor } from "@/services/professorService"

const state = {
    professors: [],
    selected: undefined,
    dialog: false,
    loading: true,
}

const getters = {
    professors(state) {
        return state.professors
    }
};


const mutations = {
    setProfessors(state, params) {
        state.professors = params;
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
    updateProfessor(state, professor) {
        const itemIndex = state.professors.findIndex(x => x.id === professor.id)
        state.professors[itemIndex] = professor;
    },
    addProfessor(state, professor) {
        state.professors.push(professor)
    },
};

const actions = {
    async fetchProfessors({ commit }) {
        commit('setLoading', true)
        commit('setProfessors', await fetchList())
        commit('setLoading', false)
    },
    setDialog({ commit }, params) {
        commit('setDialog', params)
    },
    addProfessorDialog({ commit }) {
        commit('setSelected', null)
        commit('setDialog', true)
    },
    editProfessorDialog({ commit }, params) {
        commit('setSelected', params)
        commit('setDialog', true)
    },
    async createProfessor({ commit }, professor) {
        commit('setLoading', true)
        const id = await createProfessor(professor)
        commit('addProfessor', { id, ...professor })
        commit('setSelected', null)
        commit('setLoading', false)
        commit('setDialog', false)
    },
    async updateProfessor({ commit }, professor) {
        commit('setLoading', true)
        await updateProfessor(professor)
        commit('setSelected', null)
        commit('updateProfessor', professor)
        commit('setLoading', false)
        commit('setDialog', false)
    },
    async deleteProfessor({ commit, state }, id) {
        commit('setLoading', true)
        await deleteProfessor(id)
        commit('setProfessors', state.professors.filter(i => i.id !== id))
        commit('setDialog', false)
        commit('setLoading', false)
    }
};

export default {
    state, getters, mutations, actions
};