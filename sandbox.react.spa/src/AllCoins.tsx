import React, { Component, useState, useEffect } from "react";

export function AllCoins() {
    const url: string = "https://localhost:44323/Token";

    // const [btcImage, setBtcImage] = useState(null);
    // const [name, setName] = useState(null);
    // const [price, setPrice] = useState(null);

    const [allCoinInfo, setAllCoinInfo] = useState<any[]>([]);

    useEffect(() => {
        fetch(url)
        .then(resp => resp.json())
        .then(data => {
            // setBtcImage(data[0].image);
            // setName(data[0].name);
            // setPrice(data[0].current_price);
            setAllCoinInfo(data);
            });
        const interval = setInterval(() => {
            fetch(url)
            .then(resp => resp.json())
            .then(data => setAllCoinInfo(data));
            console.log("I was just called");
        }, 10000);
        return () => clearInterval(interval);
    }, []);
    if (allCoinInfo === null) {
        return <h1>Hi</h1>
    }


    return (
        <div>
            {/* <h1>{price}</h1>
            <h1>{name}</h1>
            <img src={btcImage} height="80"/> */}
            {allCoinInfo.map(({current_price, name, image}) =>
                    <div key={current_price}>
                        <h1 key={current_price}>{current_price}</h1>
                        <h1 key={name}>{name}</h1>
                        <img key={image} src={image} height="40"/>
                    </div>
                )}
        </div>
    );
}