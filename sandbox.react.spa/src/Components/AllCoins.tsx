import React, { Component, useState, useEffect } from "react";
import { useSortBy, useTable } from "react-table";
import MaUTable from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import { Divider } from "@material-ui/core";
import '../Styles/cointable.css';

var CurrencyFormat = require('react-currency-format');

//const data: any = [];

const columns: any = [
    {
        Header: "Symbol",
        accessor: "image",
        // Footer: "Yay",
        Cell: ({row}: any) => {
            return (
                <img src={row.original.image} height="40"/>
            )
        }
    },
    {
        Header: "Name",
        accessor: "name",
        // Footer: "Footer"
    },
    {
        Header: "Current Price",
        accessor: "current_price",
        Cell: ({row}: any) => {
            return (
                <CurrencyFormat value={row.original.current_price} displayType={'text'} thousandSeparator={true} prefix={'$'} />
            )
        }
        // Footer: "Wooo"
    }
];

const Table = ({ columns, data }: any) => {
    const {
        getTableProps,
        getTableBodyProps,
        headerGroups,
        // footerGroups,
        rows,
        prepareRow,
    } = useTable({
        columns,
        data
        
    },
    useSortBy
    );

    return (
        <MaUTable {...getTableProps()}>
            <TableHead>
                {headerGroups.map(headerGroup => (
                    <TableRow {...headerGroup.getHeaderGroupProps()}>
                        {headerGroup.headers.map(column => (
                            <TableCell {...column.getHeaderProps(column.getSortByToggleProps())}>{column.render("Header")}
                                <span>
                                    {column.isSorted ? (column.isSortedDesc ? " 🔽" : " 🔼") : ""}
                                </span>
                            </TableCell>
                        ))}
                    </TableRow>
                ))}
            </TableHead>
            <TableBody>
                {rows.map((row, i) => {
                    prepareRow(row);
                    return (
                        <TableRow {...row.getRowProps()}>
                            {row.cells.map(cell => {
                                return <TableCell {...cell.getCellProps()}>{cell.render("Cell")}</TableCell>;
                            })}
                        </TableRow>
                    );
                })}
            </TableBody>
            {/* <tfoot>
                {footerGroups.map(group => (
                    <tr {...group.getFooterGroupProps()}>
                        {group.headers.map(column => (
                            <td {...column.getFooterProps()}>{column.render("Footer")}</td>
                        ))}
                    </tr>
                ))}
            </tfoot> */}
            </MaUTable>
    );
};

export function AllCoins() {
    // const url: string = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&ids=bitcoin%2C%20ethereum%2C%20tether&order=market_cap_desc&per_page=100&page=1&sparkline=false";
    //const url: string = "https://localhost:44323/Token";
    //const url: string = "https://localhost:5001/Api";
    const url: string = "https://localhost:5001/Token";


    // const [btcImage, setBtcImage] = useState(null);
    // const [name, setName] = useState(null);
    // const [price, setPrice] = useState(null);

    const [allCoinInfo, setAllCoinInfo] = useState<any[]>([]);
    const [filterInput, setFilterInput] = useState("");

    useEffect(() => {
        fetch(url)
        .then(resp => resp.json())
        .then(data => {
            // setBtcImage(data[0].image);
            // setName(data[0].name);
            // setPrice(data[0].current_price);
            setAllCoinInfo(data);
            });
        //const interval = setInterval(() => {
        //    fetch(url)
        //    .then(resp => resp.json())
        //    .then(data => setAllCoinInfo(data));
        //}, 10000);
        //return () => clearInterval(interval);
    }, []);
    if (allCoinInfo === null) {
        return <h1>Hi</h1>
    }

    const handleFilterChange = (e: any) => {
        const value = e.target.value || undefined;
        setFilterInput(value);
      };


    return (
        // <div>
        //     {/* <h1>{price}</h1>
        //     <h1>{name}</h1>
        //     <img src={btcImage} height="80"/> */}
        //     {allCoinInfo.map(({current_price, name, image}) =>
        //             <div key={current_price}>
        //                 <h1 key={current_price}>{current_price}</h1>
        //                 <h1 key={name}>{name}</h1>
        //                 <img key={image} src={image} height="40"/>
        //             </div>
        //         )}
        // </div>

        // <div>
        //     {data.map((element: any) =>
        //         <div>
        //             <img src={element.image} height="40"/>
        //             <h1>{element.name}</h1>
        //             <h1>{element.current_price}</h1>
        //         </div>
        //         )}
        // </div>

        <div>
        

        <div id="AllCoins" className="AllCoins">
            <Table id="cointable" columns={columns} data={allCoinInfo} />
        </div>
        </div>
    );
}