import { useState } from "react";
import axios from 'axios';

const SendData = (props) => {
    const [apiData, setApiData] = useState({productname:"",productqty:"",price:""});
    
    const savedata = (event) => {
        event.preventDefault();
        axios.post('http://localhost:5006/api/product', apiData);
    }

    const handleChange=(event)=>{
        const {name,value} =event.target
        setApiData({...apiData,[name]:value})

    }

    return (
        <>
            <br/><br/>
            <h4>Add new product</h4>
            <form method="POST" onSubmit={savedata}>
                <input type="text" name="productname" onChange={handleChange} placeholder="productname"/>
                <input type="text" name="productqty" onChange={handleChange} placeholder="productqty"/>
                <input type="text" name="price" onChange={handleChange} placeholder="price"/>
                <input type="Submit"/>
            </form>
        </>
    );

}
export default SendData;