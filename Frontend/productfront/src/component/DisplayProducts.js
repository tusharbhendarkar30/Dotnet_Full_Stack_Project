import { useEffect, useState } from "react";
import axios from 'axios';

const DisplayData = (props) => {
    const [apiData, setApiData] = useState([]);
    useEffect(
        () => {
            axios.get('http://localhost:5006/api/product')
                .then(response => { setApiData(response.data) });
        }
    )

    

    var tablerows = apiData.map(obj => {
        return (
            <tr>
                <td>{obj.productid}</td>
                <td>{obj.productname}</td>
                <td>{obj.productqty}</td>
                <td>{obj.price}</td>
            </tr>
        );
    });

    return (
        <>
            <br/><br/>
            <table id="productsTable">
                <tr>
                    <td>productid</td>
                    <td>productname</td>
                    <td>productqty</td>
                    <td>price</td>
                </tr>
                {tablerows}
            </table>
        </>
    );

}
export default DisplayData;