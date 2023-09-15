import React, { useState } from 'react';
import { categorys } from '../../utils/categorys';
import closeIcon from '../../images/delete.png';
import addIcon from '../../images/add.png';
import { postArticleAPI, postDataAPI } from '../../utils/fetchData';
import { imageUpload } from './../../utils/imageUpload';
import jwt from 'jsonwebtoken';
import ReactDatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css'

function formatDate(date) {
    const year = date.getFullYear();
    const month = String(date.getMonth()+1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0')

    const formatedDate = `${year}-${month}-${day}`
    return formatedDate;
}

const AddNews = ({setAddNews}) => {
    const state = {
        title: '',
        link: '',
        location: '',
        thumbnail: '',
        date:'',
        user: '',
        err: ''
    };

    const [selectedDate, setSelectedDate] = useState(null);
    const handleDateChange = (date) => {
        setSelectedDate(date);
    }

    const [news, setNews] = useState(state);
    const [images, setImages] = useState([]);
    const { title, link, location, thumbnail } = news;

    const handleChangeInput = e => {
        const { name, value } = e.target;
        setNews({...news, [name]: value, err: '', success: ''});
    };

    // const handleChangeCategory = e => {
    //     setNews({...news, category: e.target.value});
    // }

    // const handleChangeImages = e => {
    //     const files = [...e.target.files];
    //     let errMsg = "";
    //     let newImages = [];

    //     files.forEach(file => {
    //         if(!file)
    //             return errMsg = "File does not exists."
            
    //         if(file.size > 1024 * 1024 * 5){
    //             return errMsg = "The image largest is 5MB.";
    //         }

    //         return newImages.push(file);
    //     })

    //     if(errMsg) 
    //         return setNews({...news, err: errMsg});
        
    //     setImages([...images, ...newImages]);
    // };

    // const deleteImages = (index) => {
    //     const newArr = [...images];
    //     newArr.splice(index, 1);
    //     setImages(newArr);
    // };

    const handleSubmit = async (e) => {
        e.preventDefault();
        
        // let media = [];
        // if (images.length === 0)
        //     return setNews({...news, err: "Please Add photo."});

        // const id = jwt.decode(localStorage.getItem("user")).id;
        try {
            // if(images.length > 0) 
            // media = await imageUpload(images);
            // await postDataAPI('addnews', { title, link, location, images: media, user: id});
            try{
                console.log(formatDate(selectedDate))
            }catch(err) {
                console.log('error hereererere')
                console.log(err.message)
            }
            await postArticleAPI({ title, link, location, thumbnail, date:formatDate(selectedDate)});
        } catch (err) {
            err.response.data.msg && setNews({...news, err: err.response.data.msg});
        }
        // setImages([]);
        setAddNews(false);
    }

    return (
        <div className="addNews__main">
            <button className="addNews__close btn" onClick={() => setAddNews(false)}>
                <img className="icon" src={closeIcon} alt="close button" />
            </button>
            <form className="addNews__form">
                <h2 className="addNews__title">Add News</h2>
                <label className="addNews__label" htmlFor="title">Title:</label>
                <input
                    className="addNews__input"
                    type="text" 
                    id="title"
                    name="title"
                    placeholder="Enter title..."
                    onChange={handleChangeInput}
                    value={title}
                />
                <label className="addNews__label" htmlFor="">Link:</label>
                <input
                    className="addNews__input"
                    type="text" 
                    id="link"
                    name="link"
                    placeholder="Enter link..."
                    onChange={handleChangeInput}
                    value={link}
                />
                {/* <label className="addNews__label" htmlFor="category">Category:</label>
                <select value={category} onChange={handleChangeCategory} id="category" className="addNews__category">
                    <option className="addNews__option" value=""></option>
                    {
                        categorys.map((cat) => (
                            <option className="addNews__option" value={cat.name}>{cat.name}</option>
                        ))
                    }
                </select> */}
                <label className="addNews__label" htmlFor="">Location:</label>
                <input
                    className="addNews__input"
                    type="text" 
                    id="location"
                    name="location"
                    placeholder="Enter location..."
                    onChange={handleChangeInput}
                    value={location}
                />
                <label className="addNews__label" htmlFor="">Date:</label>
                <ReactDatePicker
                    selected={selectedDate}
                    onChange={handleDateChange}
                    dateFormat="yyyy-MM-dd"
                    placeholder={selectedDate}
                ></ReactDatePicker>
                {/* <label className="addNews__label" htmlFor="file_up">Images</label>
                <div className="addNews__imgUpload">
                    <img className="addNews__add" src={addIcon} alt="add news" />
                    <input onChange={handleChangeImages} className="addNews__images" type="file" name="file" id="file_up" accept="image/*" multiple/>
                </div>
                
                <div className="addNews__showimg">
                    {
                        images.map((img, index) => (
                            <div key={index} id="file__img">
                                <img className="addNews__thumb" src={URL.createObjectURL(img)} alt="images" />
                                <span onClick={() => deleteImages(index)}>&times;</span>
                            </div>
                        ))
                    }
                </div> */}
                <label className="addNews__label" htmlFor="">Image:</label>
                <input
                    className="addNews__input"
                    type="text" 
                    id="thumbnail"
                    name="thumbnail"
                    placeholder="Enter image link..."
                    onChange={handleChangeInput}
                    value={thumbnail}
                />
                <button onClick={handleSubmit} className="btn btn--primary addNews__btn">
                    Add
                </button>
            </form>
        </div>
    )
};

export default AddNews;