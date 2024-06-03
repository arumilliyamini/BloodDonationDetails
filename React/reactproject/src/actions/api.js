import {Axios, axios} from 'axios';
import { dCandidate } from '../reducers/dCandidate';
import { fetchall } from './dCandidate';

const baseurl = "https://localhost:7257/api";

export default {
    dCandidate(url = baseurl + 'dCandidate/'){
        return{
            fetchall : () => axios.get(url),
            fetchById : id => axios.get(url+id),
            create : newRecord =>axios.post(url.newRecord),
            update : (id,updatedRecord) => axios.put(url + id.updatedRecord),
            delete : id => axios.delete(url + id)
        }
    }
}