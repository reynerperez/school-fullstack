
import Vuex from "vuex";
import students from "./students"
import professors from "./professors"


export default new Vuex.Store({
    modules: {
        students: { namespaced: true, ...students },
        professors: { namespaced: true, ...professors }
    }
});