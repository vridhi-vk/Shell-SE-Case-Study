import React from 'react'
import '../styles/homecard.css'
import { Link } from 'react-router-dom';
const HomeCard = ({n}) => {
    return (
            <div className="card">
                <div className="image">
                    <img src={n.thumbnail} alt="news"/>
                </div>
                <div className="title">
                    <h1>{n.title}</h1>
                </div>
                <div className="des">
                    <button className="homecard__btn"><a className="btn1" rel="noreferrer" target="_blank" href={n.link}>Read More...</a></button>
                </div>
            </div>
    )
}

export default HomeCard
