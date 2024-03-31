use std::{error::Error, io::{Read, Write}, net::TcpStream};


fn download_content(host: &str, path: &str) -> Result<String, Box<dyn Error>> {
    let mut stream = TcpStream::connect(host)?;

    let request = format!("GET {path} HTTP/1.1\r\nHost: {host}\r\nConnection: close\r\n\r\n");
    stream.write_all(request.as_bytes())?;

    let mut buffer = Vec::new();
    stream.read_to_end(&mut buffer)?;

    let result = std::str::from_utf8(&buffer)?;
    Ok(result.to_string())
}

pub fn solve() {
    println!("{}", download_content("rest.uniprot.org:80", "/uniprotkb/P07204.fasta").unwrap())
}