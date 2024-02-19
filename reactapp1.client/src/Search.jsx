// eslint-disable-next-line no-unused-vars
import React, { useState } from 'react';
import axios from 'axios';

const Search = () => {
    const [query, setQuery] = useState('');
    const [results, setResults] = useState([]);

    const handleChange = (event) => {
        setQuery(event.target.value);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const response = await axios.get(`https://api.bing.microsoft.com/v7.0/search?q=${query}`, {
                headers: {
                    // eslint-disable-next-line no-undef
                    'Ocp-Apim-Subscription-Key': '48c78f77c0c8468bbe16548d1cbf4d15',
                },
            });
            console.log('Values : ', response.data.webPages.value)
            setResults(response.data.webPages.value);
        } catch (error) {
            console.error('Error fetching search results:', error);
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit} style={{ display: 'flex', alignItems: 'center', marginBottom: '20px' }}>
                <input
                    type="text"
                    value={query}
                    onChange={handleChange}
                    style={{
                        padding: '10px',
                        fontSize: '16px',
                        border: '2px solid #ccc',
                        borderRadius: '4px',
                        marginRight: '10px',
                        flex: '1'
                    }}
                    placeholder="Enter your search query"
                />
                <button
                    type="submit"
                    style={{
                        padding: '10px 20px',
                        fontSize: '16px',
                        backgroundColor: '#007bff',
                        color: '#fff',
                        border: 'none',
                        borderRadius: '4px',
                        cursor: 'pointer'
                    }}
                >
                    Search
                </button>
            </form>

            {/* <form onSubmit={handleSubmit}>
                <input type="text" value={query} onChange={handleChange} />
                <button type="submit">Search</button>
            </form> */}
            <ul>
                {results.map((result) => (
                    <li key={result.id}>
                        <a href={result.url}>{result.name}</a>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Search;