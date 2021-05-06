CREATE USER 'EBankingConnector'@'localhost' IDENTIFIED BY 'Pa$$w0rd';
GRANT UPDATE, INSERT, SELECT, DELETE  ON `e-banking`.* TO 'EBankingConnector'@'localhost';
FLUSH PRIVILEGES;e-banking