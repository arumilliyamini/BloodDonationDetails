import logo from './logo.svg';
import './App.css';
import {store} from "./actions/store"
import {Provider} from "react-redux"
import DCandidate from './components/DCandidate';
function App() {
  return (
    <Provider store={store}>
      <DCandidate/>
    </Provider>
  );
}

export default App;
