import { useState } from "react";
import axios from 'axios';

const SendData = (props) => {
    const [apiData, setApiData] = useState({productid:""});
    
    const deleteStd = (event) => {
        event.preventDefault();
        axios.delete(`http://localhost:5006/api/product/${apiData.productid}`);
    }

    const handleChange=(event)=>{
        const {name,value} =event.target
        setApiData({...apiData,[name]:value})
    }

    return (
        <>
            <br/><br/>
            <h4>Enter productid to be deleted.</h4>
            <form method="GET" onSubmit={deleteStd}>
                <input type="text" name="productid" onChange={handleChange} placeholder="productid"/>
                <input type="Submit" value="Delete"/>
            </form>
        </>
    );

}
export default SendData;