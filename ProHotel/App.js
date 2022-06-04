import logo from './logo.png';
import './App.css';
import Button from "react-bootstrap/Button";
import 'bootstrap/dist/css/bootstrap.min.css'

function App() {
    return (
        <div className="App">
            <div className="row-cols-auto header">
                <img src={logo} className="col-md-3 logo" alt="logo"/>
                <input className="input col-md-6 " defaultValue="Szukajka"/>
                <div className="row-cols-auto categoriesButtons">
                    <Button className="col-md-2 categoriesButton bg-dark border-dark alert-dark btn-dark">Strona główna</Button>
                    <Button className="col-md-2 categoriesButton bg-dark border-dark alert-dark btn-dark">Kategorie</Button>
                    <Button className="col-md-2 categoriesButton bg-dark border-dark alert-dark btn-dark">Kontakt</Button>
                </div>
            </div>
            <div className="main">
                <div className="content">
                    <p className="text">
                        Jak to jakiś fajny hotel będzie
                    </p>
                </div>
            </div>
        </div>
    );
}

export default App;
