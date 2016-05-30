
describe 'POST /qr/encode' do
  it 'encode a message to QR code' do
    post "/qr/encode/"

    expect(response).to be_success
end
