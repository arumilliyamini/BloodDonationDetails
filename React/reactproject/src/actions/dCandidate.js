import api from "./api";
//in redux action asyncronous api calls not allowed
//to allow api calls we installed redux-thunk package
//...................
//redux action
// export const create = data => {
//     return {
//         type : 'create',
//         payload : data
//     }
// }

export const ACTION_TYPES = {
    CREATE : 'CREATE',
    UPDATE : 'UPDATE',
    DELETE : 'DELETE',
    FETCH_ALL : 'FETCH_ALL'
}

// export const fetchall = () =>{
//     return dispatch => {

//     }
// }

//...simplified version of above fetchall function

export const fetchall = () => dispatch => {
    //get api request
    api.dCandidate()
    .then(
        response => {
            dispatch({
                type: ACTION_TYPES.FETCH_ALL,
                payload: response.data
            })
        }
    )
    .catch(err => console.log(err))
}