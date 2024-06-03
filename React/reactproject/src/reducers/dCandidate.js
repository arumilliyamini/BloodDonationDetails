import {ACTION_TYPES} from "../actions/dCandidate";

//state: we are saying what info we have to store inside redux, for storing data we need array
//action: action object will passed to this parameter
const initialstate = {
    list:[]
}

export const dCandidate = (state = initialstate, action) => {
    switch (action.type) {
        case ACTION_TYPES.FETCH_ALL:
            return{
                ...state,
                list: [...action.payload] //spread perator
            }
        default:
            return state
    }
}