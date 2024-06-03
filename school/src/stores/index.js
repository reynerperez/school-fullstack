
import Vuex from "vuex";
import students from "./students"


export default new Vuex.Store({
    modules: {
        students: { namespaced: true, ...students }
    }
});