export class SeatsService {
    readonly charset = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';

    generateSeatNumber() {
        const charsetIndex = Math.floor(Math.random() * this.charset.length);
        return Math.floor(Math.random() * 10) + this.charset[charsetIndex];
    }
}
